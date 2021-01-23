    foreach (var item in items.Join(items2, i => i.Seq, i => i.Seq, (a, b) => new
       {
            SeqID = a.Seq, 
            Answer = this.GetTheAnswer(Convert.ToDouble(a.Oil),
                                       Convert.ToDouble(b.Oil)),
            Name = a.Name, // b.Name?
            Date = a.Date, // b ?
            seqNum  = a.seqNum // b ?
       }))
