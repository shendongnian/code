    public void CreatePowerpoint()
        {
            string[] fileArray = Directory.GetFiles(@"C:\Users\Me\Desktop\test");
            Microsoft.Office.Interop.PowerPoint.Application pptApp = new Microsoft.Office.Interop.PowerPoint.Application();
            for (int i = 0; i < fileArray.Length; i++)
            {
                string file = fileArray[i];
                Microsoft.Office.Interop.PowerPoint.Presentation powerpoint = pptApp.Presentations.Open(file);
                powerpoint.UpdateLinks();
                Microsoft.Office.Interop.PowerPoint.Slides slides = powerpoint.Slides;
                Microsoft.Office.Interop.PowerPoint.Slide slide = slides[1];
                Microsoft.Office.Interop.PowerPoint.Shapes pptShapes = (Microsoft.Office.Interop.PowerPoint.Shapes)slide.Shapes;
                foreach (Microsoft.Office.Interop.PowerPoint.Shape y in pptShapes)
                {
                    Microsoft.Office.Interop.PowerPoint.Shape j = (Microsoft.Office.Interop.PowerPoint.Shape)y;
                    try
                    {
                        if (j.LinkFormat != null)
                        {
                            j.LinkFormat.BreakLink();
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                powerpoint.SaveAs(@"C:\Users\Me\Desktop\test" + i + ".pptx");
                powerpoint.Close();
                Thread.Sleep(3000);
            }
            pptApp.Quit();
        }
