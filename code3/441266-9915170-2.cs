    using System.Collections.Generic;
    using System.Linq;
    // ...
    public IList<string> CheckedValues
    {
        get { return chkList.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList(); }
    }
