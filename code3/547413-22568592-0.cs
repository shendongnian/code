    try
                {
                    //Show the Open File Dialog Box
                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.Filter = "Image files|*.bmp;*.gif;*.jpg";
    
                    //Try It First With Monochrome Bmp Image : try it with 384x384 px
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        //Init your stuff here
                        PosExplorer explorer;
                        DeviceInfo _device;
                        PosPrinter _oposPrinter;
    
                        explorer = new PosExplorer();
                        _device = explorer.GetDevice(DeviceType.PosPrinter, "T20PRINTER");
    
                        _oposPrinter = (PosPrinter) explorer.CreateInstance(_device);
                        _oposPrinter.Open();
                        if (!_oposPrinter.Claimed)
                        {
                            _oposPrinter.Claim(5000);
                            _oposPrinter.DeviceEnabled = true;
                            PrinterStation CurrentStation = PrinterStation.Receipt;
    
                            //This is a Header :
                            _oposPrinter.PrintNormal(PrinterStation.Receipt, "Here is your LOGO : ");
    
                            //Printing Your Logo :
                            int alignment; 
                            if (cbAlignment.Text == "Left")
                                alignment = PosPrinter.PrinterBarCodeLeft;
                            else if (cbAlignment.Text == "Center")
                                alignment = PosPrinter.PrinterBarCodeCenter;
                            else if (cbAlignment.Text == "Right")
                                alignment = PosPrinter.PrinterBarCodeRight;
                            else
                                alignment = int.Parse(cbAlignment.Text, System.Globalization.CultureInfo.CurrentCulture);
    
                            //Print it : you can try 384px for real size in tbWidth
                            _oposPrinter.PrintBitmap(
                                CurrentStation,
                                dlg.FileName,
                                int.Parse(tbWidth.Text, System.Globalization.CultureInfo.CurrentCulture),
                                alignment);
    
                            //Cutting your Paper :
                            _oposPrinter.CutPaper(95);
                        }
    
                    }
    
                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }
