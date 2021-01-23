    public IList<Delivery> GetDeliveries() {
        var res = new List<Delivery>();
        foreach (var v in visits) {
            if (v.KindOfVisit == VisitKind.Delivery) {
                res.Add((Delivery)v);
            }
        }
        return res;
    }
