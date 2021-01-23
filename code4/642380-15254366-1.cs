<pre>private void DrawItem(object sender, DrawItemEventArgs e)
{
    e.DrawBackground();
    e.DrawFocusRectangle();  
    // You'll change the font size here. Notice the 20
    e.Graphics.DrawString(data[e.Index],new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold), new SolidBrush(color[e.Index]),e.Bounds);
}  
private void MeasureItem(object sender, MeasureItemEventArgs e)
{
    // You may need to experiment with the ItemHeight here..
    e.ItemHeight = 25;
}</pre>
