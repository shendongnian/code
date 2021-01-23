        static void test1()
        {
            CngKey k;
            if (CngKey.Exists("myECDH", CngProvider.MicrosoftSoftwareKeyStorageProvider, CngKeyOpenOptions.MachineKey))
            {
                k = CngKey.Open("myECDH", CngProvider.MicrosoftSoftwareKeyStorageProvider, CngKeyOpenOptions.MachineKey);
            }
            else
            {
                k = CngKey.Create(CngAlgorithm.ECDiffieHellmanP256, "myECDH", new CngKeyCreationParameters
            {
                ExportPolicy = CngExportPolicies.AllowPlaintextExport,
                KeyCreationOptions = CngKeyCreationOptions.MachineKey,
                KeyUsage = CngKeyUsages.AllUsages,
                Provider = CngProvider.MicrosoftSoftwareKeyStorageProvider,
                UIPolicy = new CngUIPolicy(CngUIProtectionLevels.None)
            });
            }
            byte[] privateBytes = k.Export(CngKeyBlobFormat.EccPrivateBlob);
            byte[] publicBytes = k.Export(CngKeyBlobFormat.EccPublicBlob);
            //This:
            var privateTester1 =
                new ECDiffieHellmanCng(CngKey.Import(privateBytes, CngKeyBlobFormat.EccPrivateBlob,
                    CngProvider.MicrosoftSoftwareKeyStorageProvider));
            //Or that:
            var privateTester2 = new ECDiffieHellmanCng(k);
        }
