    CustomObject BizRule3293(IEnumerable<CustomObject> objects)
    {
        CustomObject id1 = objects.SingleOrDefault(t => t.Id == 1);
        CustomObject id3 = objects.SingleOrDefault(t => t.Id == 3);
        if (id1 != null && id3 !=null)
        {
            if (!id1.IsPrivate && !id3.IsPrivate)
                return id1.Points > id3.Points ? id1 : id3;
            return id1.IsPrivate ? id3 : id1;
            // No logic stated if both are private
        }
        return id1 ?? id3;
    }
