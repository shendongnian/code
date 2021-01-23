    using System.Collections.Generic;
    using System.Diagnostics;
    using Spring.Expressions;
    namespace StackOverflow10159903
    {
      internal class Program
      {
        private static void Main(string[] args)
        {
          var attachments = new FileAttachmentsContainer();
          attachments.AddAttachment(new FileAttachment {DownloadedPath = "CMA"});
          var value =
            ExpressionEvaluator.GetValue(attachments, "FileAttachments?{DownloadedPath.Contains('CMA')}.count()>0") as bool?;
          Debug.Assert(value == true);
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
