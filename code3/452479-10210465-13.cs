    [Task("PGPDecrypt", typeof(PGPDecryptTaskContext), "Decrypt a file with PGP encryption", Category = "File Encryption")]
    public class PGPDecryptTask : AbstractTask
    {
        public PGPDecryptTask(TaskList owner, dynamic context) : base(owner, context as ITaskContext) { }
        public override bool Process(dynamic profile, dynamic procContext)
        {
            string inputFile = procContext[TaskContext.InputFileField];
            if (!File.Exists(inputFile))
                return false;
            string outputFile;
            if (Regex.IsMatch(inputFile, TaskContext.OutputFileMatchPattern))
                outputFile = Regex.Replace(inputFile, TaskContext.OutputFileMatchPattern, TaskContext.OutputFileReplacePattern, RegexOptions.IgnoreCase);
            else
                return false;
            PGPEncryptDecrypt.Decrypt(inputFile, TaskContext.PrivateKeyFile, TaskContext.Passphrase, outputFile);
            return true;
        }
    }
