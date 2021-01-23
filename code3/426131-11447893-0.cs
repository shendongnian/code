                foreach (Word.FormField oFormFields in oDoc.FormFields)
                {
                    //To Get Bookmark Name
                    if (oFormFields.Name.Contains("CompanyEntity"))
                    {
                        //With Values
                        BMClick = BMClick + "," + oFormFields.Name;
                        BMType = oFormFields.Type.ToString();
                        BMClick = BMClick + "," + BMType + "," + oFormFields.Result + "\n";
                    }
                    //from here: get all BM names
                    //if (oFormFields.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldFormTextInput)
                    //{
                    //    ////To Get Bookmark Name
                    //    //if ((oFormFields.Name.ToUpper().Contains("LR_M_IssueDate")) || (oFormFields.Name.ToUpper().Contains("LR_O_ExpiryDate")))
                    //    //{
                    //    //    BMClick = BMClick + "," + oFormFields.Name;
                    //    //}
                    //    //With Values
                    //    //BMClick = BMClick + "," + oFormFields.Name;
                    //    //BMType = oFormFields.Type.ToString();
                    //    //BMClick = BMClick + "," + BMType + "," + oFormFields.Result + "\n";
                    ////To check the text field format
	    //    switch (((Microsoft.Office.Interop.Word.WdTextFormFieldType)oFormFields.TextInput.Type))
                    //    {
                    //        case Microsoft.Office.Interop.Word.WdTextFormFieldType.wdRegularText:
                    //            {
                    //                ////To Get Bookmark Name
                    //                //if ((oFormFields.Name.ToUpper().Contains("LR_M_IssueDate")) || (oFormFields.Name.ToUpper().Contains("LR_O_ExpiryDate")))
                    //                //{
                    //                //    BMClick = BMClick + "," + oFormFields.Name;
                    //                //}
                    //                BMClick = BMClick + "," + oFormFields.Name;
                    //                BMType = oFormFields.Type.ToString();
                    //                BMClick = BMClick + "," + BMType;
                    //                BMTextType = oFormFields.TextInput.Type.ToString();
                    //                BMClick = BMClick + "," + BMTextType + "\n";
                    //                break;
                    //            }
                    //        case Microsoft.Office.Interop.Word.WdTextFormFieldType.wdDateText:
                    //            //if ((oFormFields.Name.ToUpper().Contains("LR_M_ISSUEDATE")) || (oFormFields.Name.ToUpper().Contains("LR_O_EXPIRYDATE")))
                    //            //{
                    //            //    BMClick = BMClick + "," + oFormFields.Name;
                    //            //}
                    //            BMClick = BMClick + "," + oFormFields.Name;
                    //            BMType = oFormFields.Type.ToString();
                    //            BMClick = BMClick + "," + BMType;
                    //            BMTextType = oFormFields.TextInput.Type.ToString();
                    //            BMClick = BMClick + "," + BMTextType + "\n";
                    //            break;
                    //        case Microsoft.Office.Interop.Word.WdTextFormFieldType.wdNumberText:
                    //            BMClick = BMClick + "," + oFormFields.Name;
                    //            BMType = oFormFields.Type.ToString();
                    //            BMClick = BMClick + "," + BMType;
                    //            BMTextType = oFormFields.TextInput.Type.ToString();
                    //            BMClick = BMClick + "," + BMTextType + "\n";
                    //            break;
                    //        default:
                    //            //MessageBox.Show("no");
                    //            break;
                    //    }
                    //}
                    //else if (oFormFields.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldFormCheckBox)
                    //{
                    //    BMClick = BMClick + "," + oFormFields.Name;
                    //    BMType = oFormFields.Type.ToString();
                    //    BMClick = BMClick + "," + BMType + "," + oFormFields.Result + "\n";
                    //}
                    ////{
                    ////    if (oFormFields.Name == "")
                    ////    { 
                    ////        Word.Range curPageRange = new Word.Range;
                    ////        object AtPage = @"\page";
                    ////        curPageRange = oDoc.Bookmarks.get_Item(ref AtPage).Range;
                    ////        //curPageRange.Select(); 
                    ////        BMClick=BMClick + "," + curPageRange;
                    ////    }
                    ////}
                    //else if (oFormFields.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldFormDropDown)
                    //{
                    //    BMClick = BMClick + "," + oFormFields.Name;
                    //    BMType = oFormFields.Type.ToString();
                    //    BMClick = BMClick + "," + BMType + "," + oFormFields.Result + "\n";
                    //}
                    ////{
                    ////    if (oFormFields.Name == "")
                    ////    { 
                    ////        Word.Range curPageRange = new Word.Range;
                    ////        object AtPage = @"\page";
                    ////        curPageRange = oDoc.Bookmarks.get_Item(ref AtPage).Range;
                    ////        //curPageRange.Select(); 
                    ////        BMClick=BMClick + "," + curPageRange;
                    ////    }
                    ////}
                    //until here: get all BM names
                    ctr++;
                    // }
                }
