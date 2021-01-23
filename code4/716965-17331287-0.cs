    foreach (Projectile po in Plist)
    {
        if (Vector2.Distance(po.Position, po.Target) < 10)
        {
            po.Remove = true;
        }
    }
    for (int i = 0; i < Plist.Count; i++)
    {
        if(Plist[i].Remove);
        Plist.RemoveAt(i);
    }
