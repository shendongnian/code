    // ... Some Other Code ...
    @using(Html.BeginForm()) // Creates <form>
    {
        Html.Hidden(
            "HiddenName",
            ViewBag.MyHiddenInputValue,
            new { @class = "hiddencss", maxlength = 255 /*, etc... */ }
        );
    }
    // ... Some Other Code ...
