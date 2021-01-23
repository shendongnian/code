    public class MyChicken : GridCore
    {
        public string FavouriteColour { get; set; }
    }
    ....
    new MyTest<MyAlbum>().DoTest1(new MyChicken());
