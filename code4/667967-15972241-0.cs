    IEnumerable<MyClass> oMyClass = db.Database.SqlQuery<MyClass>("SELECT ...");
    foreach (var o in oMyClass)
    {
        // do somethig with o
    }
    return Json(oMyClass, JsonRequestBehavior.AllowGet);
}
