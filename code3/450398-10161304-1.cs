    using System.Collections.Generic;
    using System.Diagnostics;
    using Spring.Expressions;
    namespace StackOverflow10159903
    {
      internal class Program
      {
        private static void Main(string[] args)
        {
          var attachmentContainer = new FileAttachmentsContainer();
          attachmentContainer.AddAttachment(new FileAttachment {DownloadedPath = "CMA"});
          var attachments = new List<FileAttachment>();
          attachments.Add(new FileAttachment {DownloadedPath = "CMA"});
          var valueFromList =
            ExpressionEvaluator.GetValue(attachments, "?{DownloadedPath.Contains('CMA')}.count()>0") 
            as bool?;
          var valueFromContainer =
            ExpressionEvaluator.GetValue(attachmentContainer, "FileAttachments?{DownloadedPath.Contains('CMA')}.count()>0")
            as bool?;
          Debug.Assert(valueFromList == true);
          Debug.Assert(valueFromContainer == true);
        }
      }
      public class FileAttachmentsContainer
      {
        private readonly List<FileAttachment> _fileAttachments;
        public FileAttachmentsContainer()
        {
          _fileAttachments = new List<FileAttachment>();
        }
        public IEnumerable<FileAttachment> FileAttachments
        {
          get { return _fileAttachments; }
        }
        public void AddAttachment(FileAttachment fileAttachment)
        {
          _fileAttachments.Add(fileAttachment);
        }
      }
      public class FileAttachment
      {
        public string DownloadedPath { get; set; }
      }
    }
