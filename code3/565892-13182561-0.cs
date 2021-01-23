    private Greyhound dog1; // Declare the field here
    public void LoadDogs()
    {
        // Give the field a value here
        dog1 = new Greyhound
        {
            StartingPosition = 30,
            MyPictureBox = pictureBox2, //Pointer at the picture box for this dog.
            Location = 30,  //X cordinates of the picture box
            Lane = 21 //Y cordinates of the picture box
        };
    }
