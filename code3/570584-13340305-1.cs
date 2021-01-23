    using Microsoft.Office.Core;
    using PowerPoint = Microsoft.Office.Interop.PowerPoint;
    using System.IO;
    using Microsoft.Office.Interop.PowerPoint;
    
    namespace SavePPT
    {
            class Program
            {
                static void Main(string[] args)
                {
                    string fileName = @"C:\Presentation1.pptx";
                    string exportName = "video_of_presentation";
                    string exportPath = @"C:\{0}.wmv";
    
                    Microsoft.Office.Interop.PowerPoint.Application ppApp = new Microsoft.Office.Interop.PowerPoint.Application();
                    ppApp.Visible = MsoTriState.msoTrue;
                    ppApp.WindowState = PpWindowState.ppWindowMinimized;
                    Microsoft.Office.Interop.PowerPoint.Presentations oPresSet = ppApp.Presentations;
                    Microsoft.Office.Interop.PowerPoint._Presentation oPres = oPresSet.Open(fileName,
                                MsoTriState.msoFalse, MsoTriState.msoFalse,
                                MsoTriState.msoFalse);
                    try
                    {
                        oPres.CreateVideo(exportName);
                        oPres.SaveCopyAs(String.Format(exportPath, exportName),
                            PowerPoint.PpSaveAsFileType.ppSaveAsWMV,
                            MsoTriState.msoCTrue);
                    }
                    finally
                    {
                        ppApp.Quit();
                    }
                }
            }
    }
