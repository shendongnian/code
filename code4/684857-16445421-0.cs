    private List<TextBox> GetTB(Grid Grd)
    {
        List<TextBox> _lstT = new List<TextBox>();
        try
        {
            // get ALL TextBox in main Grid and sub Grid/UniformGrid
            UIElementCollection _mainGrd = Grd.Children;
            foreach (UIElement el in _mainGrd)
            {
                if (el is TextBox) { _lstT.Add((TextBox)el); }
                else if (el is Grid)
                {
                    foreach (UIElement el1 in ((Grid)el).Children)
                    { if (el1 is TextBox) { _lstT.Add((TextBox)el1); } }
                }
                else if (el is UniformGrid)
                {
                    foreach (UIElement el1 in ((UniformGrid)el).Children)
                    { if (el1 is TextBox) { _lstT.Add((TextBox)el1); } }
                }
            }
            return _lstT;
        }
        catch { throw; }
    }
