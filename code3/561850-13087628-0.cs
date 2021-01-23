    class Character
    {
    static List<Character> characterList=new List<Character>();//all characters are here
    public Character(int id,...)
    {
    ..
    characterList.Add(this);//store them in the list as and when created
    }
    
    internal Character SearchByID(string _ID)
    {
       foreach(Character charToFind in characterList)
       {
           if(charToFind.ID == _ID)
           return charToFind;
       }
    }
    
    
    }
