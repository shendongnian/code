    using System.Linq;
    SPListCollection listCollection = web.Lists;
    IEnumerable<SPList> lists = listCollection.Cast<SPList>();
    foreach (SPList list in lists)
    {
