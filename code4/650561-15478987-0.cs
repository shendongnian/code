    private void GenerateTransform(string baseMSI, string outputMST)
    {
        string tempMSI = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), Guid.NewGuid().ToString() + ".msi");
        File.Copy(baseMSI, tempMSI, true);
        using (var baseDatabase = new Database(baseMSI, DatabaseOpenMode.ReadOnly))
        {
            using (var tempDatabase = new Database(tempMSI, DatabaseOpenMode.Direct))
            {
                // Do Stuff Here
                // Finally, Generate Transform
                tempDatabase.GenerateTransform(baseDatabase, outputMST);
                tempDatabase.CreateTransformSummaryInfo(baseDatabase, outputMST, TransformErrors.None, TransformValidations.None);
            }
        }
        File.Delete(tempMSI);
    }
