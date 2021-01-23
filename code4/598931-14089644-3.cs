            using (TransactionScope tr = new TransactionScope())
            {
                TsansactionalFileWriter writer = new TsansactionalFileWriter("c:\\myFile.txt");
                writer.AppendText("sdfgssdfgsdf");
                tr.Complete();
            }
