     using (StreamWriter sw = File.CreateText(LocalFile)) { }
                File.SetCreationTime(LocalFile,DateTime.Now);
                Thread.Sleep(50);
                
                using (StreamWriter sw = File.CreateText(UncFile)) { }
                File.SetCreationTime(UncFile, DateTime.Now);
                Thread.Sleep(50);
    
                DateTime UncDate = File.GetCreationTime(UncFile);
                DateTime OldLocalDate = File.GetCreationTime(LocalFile);
    
                Assert.IsTrue(UncDate > OldLocalDate);
