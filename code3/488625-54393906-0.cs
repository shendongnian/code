            try
            {
                bpac.Document mylabel = new bpac.Document();
                if (mylabel.Open("SensorNodeLabel.lbx"))
                {
                    mylabel.GetObject("labelText").Text = "blah blah";
                   
                    mylabel.StartPrint("", bpac.PrintOptionConstants.bpoDefault);
                    mylabel.PrintOut(1, bpac.PrintOptionConstants.bpoDefault);
                    mylabel.EndPrint();
                    mylabel.Close();
                }
            }
            catch ...
