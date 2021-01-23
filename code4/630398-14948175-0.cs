    static void renderHTML(string folder, string outputFile, int imagesPerRow, params string[] extensions) {
            string[] images = Directory.GetFiles(folder);
            using (var sw = new StreamWriter(File.OpenWrite(outputFile))) {
                sw.WriteLine("<!html><head><title>Example</title></head><body><table>");
                int counter = 0;
                sw.Write("<tr>");
                foreach (string image in images.Where(x => extensions.Any(y => x.Contains(y)))) {
                    if (counter == imagesPerRow) {
                        sw.Write("</tr>");
                        sw.Write("<tr>");
                        counter = 0;
                    }
                    sw.Write("<td style=\"border: 1px solid;\">");
                    sw.Write(string.Format("<img src=\"{0}\" />", image));
                    sw.Write("</td>");
                    counter++;
                }
                sw.Write("</tr></table></body></html>");
            }
        }
