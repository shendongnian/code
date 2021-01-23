    using System;
    using System.Collections.Generic;
    using Moq;
    using MoqRefProblem;
    using NUnit.Framework;
    
    namespace MoqRefProblem
    {
        //This class is the one we want to have passed by ref.
        public class FileContext
        {
            public int LinesProcessed { get; set; }
            public decimal AmountProcessed { get; set; }
        }
        
        public interface IRecordParser
        {
            //The ref parameter below is what's creating the testing problem.
            void ParseLine(decimal amount, ref FileContext context);
        }
    
        //This is problematic because we don't have a 
        //seam that allows us to set the FileContext.
        public class OriginalFileParser
        {
            private readonly IRecordParser _recordParser;
    
            public OriginalFileParser(IRecordParser recordParser)
            {
                _recordParser = recordParser;
            }
    
            public void ParseFile(IEnumerable<decimal> items)
            {
                //This is the problem
                var context = new FileContext();
                ParseItems(items, ref context);
            }
    
            private void ParseItems(IEnumerable<decimal> items, ref FileContext context)
            {
                foreach (var item in items)
                {
                    _recordParser.ParseLine(item, ref context);
                }
            }
        }
    
        }
    
        //This class has had the creation of the FileContext extracted into a virtual 
        //method. 
        public class FileParser
        {
            private readonly IRecordParser _recordParser;
    
            public FileParser(IRecordParser recordParser)
            {
                _recordParser = recordParser;
            }
    
            public void ParseFile(IEnumerable<decimal> items)
            {
                //Instead of newing up a context, we'll get it from a virtual method 
                //that we'll override in a test class.
                var context = GetFileContext();
                ParseItems(items, ref context);
            }
    
            //This is our extensibility point
            protected virtual FileContext GetFileContext()
            {
                var context = new FileContext();
                return context;
            }
    
            private void ParseItems(IEnumerable<decimal> items, ref FileContext context)
            {
                foreach (var item in items)
                {
                    _recordParser.ParseLine(item, ref context);
                }
            }
        }
    
        //Create a test class that inherits from the Class under Test    
        //We will set the FileContext object to the value we want to
        //use.  Then we override the GetContext call in the base class 
        //to return the fileContext object we just set up.
        public class MakeTestableParser : FileParser
        {
            public MakeTestableParser(IRecordParser recordParser)
                : base(recordParser)
            {
            }
    
            private FileContext _context;
    
            public void SetFileContext(FileContext context)
            {
                _context = context;
            }
    
            protected override FileContext GetFileContext()
            {
                if (_context == null)
                {
                    throw new Exception("You must set the context before it can be used.");
                }
    
                return _context;
            }
        }
    
    [TestFixture]
    public class WorkingFileParserTest
    {
        [Test]
        public void ThisWillWork()
        {
            //Arrange
            var recordParser = new Mock<IRecordParser>();
    
            //Note that we are an instance of the TestableParser and not the original one.
            var sut = new MakeTestableParser(recordParser.Object);
            var context = new FileContext();
            sut.SetFileContext(context);
    
            var items = new List<decimal>()
                {
                    10.00m,
                    11.50m,
                    12.25m,
                    14.00m
                };
    
            //Act
            sut.ParseFile(items);
    
            //Assert
            recordParser.Verify(x => x.ParseLine(It.IsAny<decimal>(), ref context), Times.Exactly(items.Count));
        }
    }
