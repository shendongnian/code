    if (b.Id== 0)
        {
            context.B.Add(b);
        }
    else
       {
           context.B.Attach(b);
       }
       context.SaveChanges();
