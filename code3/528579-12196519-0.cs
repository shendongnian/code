    Func<System.Web.UI.ControlCollection, IEnumerable<System.Web.UI.Control>> FlattenControls = null;
    FlattenControls = coll => coll.Cast<System.Web.UI.Control>()
                                .Concat(coll.Cast<System.Web.UI.Control>()
                                            .SelectMany(x => FlattenControls(x.Controls))
                                );
    var radioButtons = FlattenControls(this.Controls).OfType<RadioButton>().ToList();
