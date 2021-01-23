	public class DiffPdfApprover : IApprovalApprover
    {
        public static void Verify(byte[] bytes)
        {
            var writer = new ApprovalTests.Writers.BinaryWriter(bytes, "pdf");
            var namer = ApprovalTests.Approvals.GetDefaultNamer();
            var reporter = ApprovalTests.Approvals.GetReporter();
            ApprovalTests.Core.Approvals.Verify(new DiffPdfApprover(writer, namer), reporter);
        }
        private DiffPdfApprover(IApprovalWriter writer, IApprovalNamer namer)
        {
            this.writer = writer;
            this.namer = namer;
        }
        private readonly IApprovalNamer namer;
        private readonly IApprovalWriter writer;
        private string approved;
        private ApprovalException failure;
        private string received;
        public virtual bool Approve()
        {
            string basename = string.Format(@"{0}\{1}", namer.SourcePath, namer.Name);
            approved = Path.GetFullPath(writer.GetApprovalFilename(basename));
            received = Path.GetFullPath(writer.GetReceivedFilename(basename));
            received = writer.WriteReceivedFile(received);
            failure = Approve(approved, received);
            return failure == null;
        }
        public static ApprovalException Approve(string approved, string received)
        {
            if (!File.Exists(approved))
            {
                return new ApprovalMissingException(received, approved);
            }
            var process = new Process();
            //settings up parameters for the install process
            process.StartInfo.FileName = "diff-pdf";
            process.StartInfo.Arguments = String.Format("\"{0}\" \"{1}\"", received, approved);
            process.Start();
            process.WaitForExit();
            if (process.ExitCode != 0)
            {
                return new ApprovalMismatchException(received, approved);
            }
            return null;
        }
        public void Fail()
        {
            throw failure;
        }
        public void ReportFailure(IApprovalFailureReporter reporter)
        {
            reporter.Report(approved, received);
        }
        public void CleanUpAfterSucess(IApprovalFailureReporter reporter)
        {
            File.Delete(received);
            if (reporter is IApprovalReporterWithCleanUp)
            {
                ((IApprovalReporterWithCleanUp)reporter).CleanUp(approved, received);
            }
        }
    }
