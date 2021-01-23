    private void SaveModel(SomeEntities context, SomeModel model bool setDt1, bool setDt2) {
      DateTime instant = DateTime.Now;
      if (SetDt1) { model.dt1 = instant; }
      if (setDt2) { model.dt2 = instant; }
      context.SaveChanges();
    }
