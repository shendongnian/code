    static void Main(string[] args)
            {
                Microsoft.Office.Interop.PowerPoint.Application PowerPoint_App = new Microsoft.Office.Interop.PowerPoint.Application();
                Microsoft.Office.Interop.PowerPoint.Presentations multi_presentations = PowerPoint_App.Presentations;
                Microsoft.Office.Interop.PowerPoint.Presentation presentation = multi_presentations.Open(@"C:\PPT\myPowerpoint.pptx");
                string presentation_text = "";
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    foreach (var item in presentation.Slides[i+1].Shapes)
                    {
                        var shape = (PowerPoint.Shape)item;
                        if (shape.HasTextFrame == MsoTriState.msoTrue)
                        {
                            if (shape.TextFrame.HasText == MsoTriState.msoTrue)
                            {
                                var textRange = shape.TextFrame.TextRange;
                                var text = textRange.Text;
                                presentation_text += text+" ";
                            }
                        }
                    }
                }
                PowerPoint_App.Quit();
                Console.WriteLine(presentation_text);
            }
