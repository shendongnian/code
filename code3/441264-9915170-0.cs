    using System.Collections.Generic;
    using System.Linq;
    // ...
    public IList<string> CheckedValues
    {
        get { return chkList.Items.Cast<ListItem>().Where(i => i.Checked).Select(i => i.Value); }
    }
