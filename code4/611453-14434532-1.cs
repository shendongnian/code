    @using (Html.BeginForm())
    {
        @Html.RadioButtonFor(m => m.MyOption, (int)MyEnum.BlackDiamond);
        <span>Black Diamond</span><br />
        @Html.RadioButtonFor(m => m.MyOption, (int)MyEnum.BlueSquare, 
            new { @checked = "true" });
        <span>Blue Square</span><br />
        @Html.RadioButtonFor(m => m.MyOption, (int)MyEnum.GreenCircle);
        <span>Green Circle</span><br />
        @Html.RadioButtonFor(m => m.MyOption, (int)MyEnum.TerrainPark);
        <span>Terrain Park</span><br />
    }
