    listB.ForEach(b =>
       {
          if (listA.Any(a => a.Car_number == b.Car_number || a.status == b.status))
          {
             listC.Add(b);
          }
          else
          {
             listA.Add(b);
          }
       }
    );
