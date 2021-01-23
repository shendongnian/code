    using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Office\14.0\PowerPoint\Security",true))
    {
        int origVal = (int)key.GetValue("AccessVBOM", 0);
        if (origVal != 1)
            key.SetValue("AccessVBOM", 1);
    
        PowerPoint.Application oPPT = new PowerPoint.Application();
        oPPT.Visible = Office.MsoTriState.msoTrue;
        //Add New Presentation
        PowerPoint.Presentations oPresSet = oPPT.Presentations;
        PowerPoint.Presentation oPres = oPresSet.Add(Office.MsoTriState.msoTrue);
        //Add Slides to the Presentation
        PowerPoint.Slides oSlides = oPres.Slides;
        PowerPoint.Slide oSlide = oSlides.Add(1, PowerPoint.PpSlideLayout.ppLayoutTitle);
        VBComponent vbc = oPres.VBProject.VBComponents.Add(vbext_ComponentType.vbext_ct_StdModule);
        string code = "sub VBAMacro()\r\n" + "ActivePresentation.Close\n" + "End Sub";
        vbc.CodeModule.AddFromString(code);
        if (origVal != 1)
        {
            key.SetValue("AccessVBOM", origVal);
        }
        key.Close();
    }
