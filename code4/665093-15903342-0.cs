    System.Reflection.Assembly CurrAssembly = System.Reflection.Assembly.LoadFrom(System.Windows.Forms.Application.ExecutablePath);
      System.IO.Stream stream = CurrAssembly.GetManifestResourceStream("Oferty_BMGRP.Resources.stopka.png");
      string temp = Path.GetTempFileName();
      System.Drawing.Image.FromStream(stream).Save(temp);
      xlWorkSheet.PageSetup.CenterFooterPicture.Filename = temp; //Application.StartupPath + "\\Resources\\stopka.png";
      xlWorkSheet.PageSetup.CenterFooterPicture.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoTrue;
      xlWorkSheet.PageSetup.CenterFooterPicture.Width = 590;
      xlWorkSheet.PageSetup.CenterFooter = "&G";
