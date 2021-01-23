    [Task("PGPEncrypt", typeof(PGPEncryptTaskContext), "Encrypt a file with PGP encryption", Category = "File Encryption")]
    public class PGPEncryptTask : AbstractTask
    {
        public PGPEncryptTask(TaskList owner, dynamic context) : base(owner, context as ITaskContext) { }
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
            if (string.IsNullOrEmpty(TaskContext.SenderKeyFile))
                PGPEncryptDecrypt.EncryptFile(inputFile, outputFile, TaskContext.RecipientKeyFile, TaskContext.Armor, true);
            else
                PGPEncryptDecrypt.EncryptAndSign(inputFile, outputFile, TaskContext.RecipientKeyFile, TaskContext.SenderKeyFile, TaskContext.SenderPassphrase, TaskContext.Armor);
            return true;
        }
    }
