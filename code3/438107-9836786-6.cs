     private void btnDumpExcel_Click(object sender, EventArgs e)
             {
             IDictionary<string, string> p = new Dictionary<string, string>();
    
             p.Add("pcomno", "020");
             p.Add("pcpls", "221");
             p.Add("pUploaderName", "Anthony Peiris");
             try
                {
                pGroupDs = O.execProc2DatSet("priceWorx.prSnapshotDiscounts", p, false, false);
                Excel.MakeWorkBook(ref pGroupDs, ref O, "1");
    
                }
             catch (Exception ex)
                {
                Debug.WriteLine(ex);
                Debugger.Break();
                }
             //Excel.MakeWorkBook(ref ds, ref O, "1");
    
             }
