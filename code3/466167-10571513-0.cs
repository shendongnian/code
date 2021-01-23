    from falta in db.Falta
    join professor in db.Professor on falta.Id_profe equals professor.Id_profe
    group new {professor, falta} by new {
      professor.Llinatge,
      professor.Nom
    } into g
    select new {
      g.Key.Nom,
      g.Key.Llinatge,
      FJ = (System.Int64?)g.Sum(p => (
      p.falta.Aprovada == true ? 1 : 0)),
      FNJ = (System.Int64?)g.Sum(p => (
      p.falta.Aprovada == false ? 1 : 0))
    };
