    public static bool HasGrandChilds(int id, int depth) {
        var lst = new List<Keywords>();
        for (var i = 0; i < depth - 1; i++) {
            if (i == 0)
            {
                //Initial search at first loop run
                lst = db.Keywords.Where(item => item.ParentId == id);
            }
            else
            {
                //Search all entries, where the parent is in our given possible parents
                lst = db.Keywords.Where(item => lst.Any(k => k.Id == item.Parent));
            }
            if (!lst.Any())
            {
                //If no more children where found, the searched depth doesn't exist
                return false;
            }
        }
        return true;
    }
