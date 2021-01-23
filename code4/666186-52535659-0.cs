    ****/*For Multiple PDF Print..!!*/****
    
    <button type="button" id="btnPrintMultiplePdf" runat="server" class="btn btn-primary btn-border btn-sm"
                                                                    onserverclick="btnPrintMultiplePdf_click">
                                                                    <i class="fa fa-file-pdf-o"></i>Print Multiple pdf</button>
    
    protected void btnPrintMultiplePdf_click(object sender, EventArgs e)
        {
            if (ValidateForMultiplePDF() == true)
            {
                #region Declare Temp Variables..!!
                CheckBox chkList = new CheckBox();
                HiddenField HidNo = new HiddenField();
    
                string Multi_fofile, Multi_listfile;
                Multi_fofile = Multi_listfile = "";
                Multi_fofile = Server.MapPath("PDFRNew");
                #endregion
    
                for (int i = 0; i < grdRnew.Rows.Count; i++)
                {
                    #region Find Grd Controls..!!
                    CheckBox Chk_One = (CheckBox)grdRnew.Rows[i].FindControl("chkOne");
                    Label lbl_Year = (Label)grdRnew.Rows[i].FindControl("lblYear");
                    Label lbl_No = (Label)grdRnew.Rows[i].FindControl("lblCode");
                    #endregion
    
                    if (Chk_One.Checked == true)
                    {
                        HidNo .Value = llbl_No .Text.Trim()+ lbl_Year .Text;
    
                        if (File.Exists(Multi_fofile + "\\" + HidNo.Value.ToString() + ".pdf"))
                        {
                            #region Get Multiple Files Name And Paths..!!
                            if (Multi_listfile != "")
                            {
                                Multi_listfile = Multi_listfile + ",";
                            }
                            Multi_listfile = Multi_listfile + Multi_fofile + "\\" + HidNo.Value.ToString() + ".pdf";
    
                            #endregion
                        }
                    }
                }
    
                #region For Generate Multiple Pdf..!!
                if (Multi_listfile != "")
                {
                    String[] Multifiles = Multi_listfile.Split(',');
                    string DestinationFile = Server.MapPath("PDFRNew") + "\\Multiple.Pdf";
                    MergeFiles(DestinationFile, Multifiles);
    
                    Response.ContentType = "pdf";
                    Response.AddHeader("Content-Disposition", "attachment;filename=\"" + DestinationFile + "\"");
                    Response.TransmitFile(DestinationFile);
                    Response.End();
                }
                else
                {
    
                }
                #endregion
            }
        }
    
        private void MergeFiles(string DestinationFile, string[] SourceFiles)
        {
            try
            {
                int f = 0;
                /**we create a reader for a certain Document**/
                PdfReader reader = new PdfReader(SourceFiles[f]);
                /**we retrieve the total number of pages**/
                int n = reader.NumberOfPages;
                /**Console.WriteLine("There are " + n + " pages in the original file.")**/
                /**Step 1: creation of a document-object**/
                Document document = new Document(reader.GetPageSizeWithRotation(1));
                /**Step 2: we create a writer that listens to the Document**/
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(DestinationFile, FileMode.Create));
                /**Step 3: we open the Document**/
                document.Open();
                PdfContentByte cb = writer.DirectContent;
                PdfImportedPage page;
                int rotation;
                /**Step 4: We Add Content**/
                while (f < SourceFiles.Length)
                {
                    int i = 0;
                    while (i < n)
                    {
                        i++;
                        document.SetPageSize(reader.GetPageSizeWithRotation(i));
                        document.NewPage();
                        page = writer.GetImportedPage(reader, i);
                        rotation = reader.GetPageRotation(i);
                        if (rotation == 90 || rotation == 270)
                        {
                            cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                        }
                        else
                        {
                            cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                        }
                        /**Console.WriteLine("Processed page " + i)**/
                    }
                    f++;
                    if (f < SourceFiles.Length)
                    {
                        reader = new PdfReader(SourceFiles[f]);
                        /**we retrieve the total number of pages**/
                        n = reader.NumberOfPages;
                        /**Console.WriteLine("There are"+n+"pages in the original file.")**/
                    }
                }
                /**Step 5: we Close the Document**/
                document.Close();
            }
            catch (Exception e)
            {
                string strOb = e.Message;
            }
        }
    
        private bool ValidateForMultiplePDF()
        {
            bool chkList = false;
    
            foreach (GridViewRow gvr in grdRnew.Rows)
            {
                CheckBox Chk_One = (CheckBox)gvr.FindControl("ChkSelectOne");
                if (Chk_One.Checked == true)
                {
                    chkList = true;
                }
            }
            if (chkList == false)
            {
                divStatusMsg.Style.Add("display", "");
                divStatusMsg.Attributes.Add("class", "alert alert-danger alert-dismissable");
                divStatusMsg.InnerText = "ERROR !!...Please Check At Least On CheckBox.";
                grdRnew.Focus();
                set_timeout();
                return false;
            }
            return true;
        }
