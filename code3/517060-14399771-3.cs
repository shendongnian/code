             OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string sDocFileName = dialog.FileName.ToString();
                SwDMClassFactory swClassFact = default(SwDMClassFactory);
                SwDMApplication swDocMgr = default(SwDMApplication);
                SwDMDocument swDoc = default(SwDMDocument);
                SwDMConfigurationMgr swCfgMgr = default(SwDMConfigurationMgr);
                string[] vCfgNameArr = null;
                SwDMConfiguration7 swCfg = default(SwDMConfiguration7);
                IPictureDisp pPreview = default(IPictureDisp);
                SwDmDocumentType nDocType = 0;
                SwDmDocumentOpenError nRetVal = 0;
                SwDmPreviewError nRetVal2 = 0;
                Image image = default(Image);
                //Access to interface
                swClassFact = new SwDMClassFactory();
                swDocMgr = (SwDMApplication)swClassFact.GetApplication("Post your code here");
                swDoc = (SwDMDocument)swDocMgr.GetDocument(sDocFileName, nDocType, false, out nRetVal);
                Debug.Assert(SwDmDocumentOpenError.swDmDocumentOpenErrorNone == nRetVal);
                swCfgMgr = swDoc.ConfigurationManager;
                pathLabel.Text = "Path to file: " + swDoc.FullName;
                configLabel.Text = "Active config: " + swCfgMgr.GetActiveConfigurationName();
                vCfgNameArr = (string[])swCfgMgr.GetConfigurationNames();
                foreach (string vCfgName in vCfgNameArr)
                {
                    //get preview
                    swCfg = (SwDMConfiguration7)swCfgMgr.GetConfigurationByName(vCfgName);
                    pPreview = (IPictureDisp)swCfg.GetPreviewPNGBitmap(out nRetVal2);
                    image = Support.IPictureDispToImage(pPreview);
                    //insert to picturebox
                    pictureBox1.BackgroundImage = image;
                }
                swDoc.CloseDoc();
            }
