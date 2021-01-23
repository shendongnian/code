    public static bool HasChild(int id) {
        return
            db.Keywords.Any(item => item.Parent == id);
    }
    public static bool HasGrandChilds(int id) {
        return
            db.Keywords.Where(item => item.Parent == id).Any(item => HasChild(item.ID);
    }
