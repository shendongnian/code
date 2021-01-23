    using System.Linq;
    var buttons = this.tableLayoutPanel1.Controls
                                        .OfType<Button>()
                                        .Where(b => b.Tag != "ControlButton");
    int index = buttons.Count();
    foreach (var button in buttons)
    {
        button.Text = String.Format("Button #{0}", index);     
        index--;
    }
