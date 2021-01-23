    public class MainWindowViewModel:ViewModelBase
    {
        private IList<Character> _characters;
        public IList<Character> Characters
        {
            get
            {
                return _characters;
            }
            set
            {
                _characters = value;
                RaisePropertyChanged(()=>Characters);
            }
        }
        private Character _character;
        public Character SelectedCharacter
        {
            get
            {
                return _character;
            }
            set
            {
                _character = value;
                RaisePropertyChanged(()=>SelectedCharacter);
            }
        }
        public MainWindowViewModel()
        {
            InitializeCharacters();
        }
        private void InitializeCharacters()
        {
            Characters = new List<Character>();
            SelectedCharacter = new Character();
            Characters.Add(new Character
            {
                Name = "Tank",
                Level = 3,
                Stats = new List<Character.Stat>()
                {
                    new Character.Stat()
                    {
                        Agility =       10,
                        Intelligence =  8, 
                        Strength =      14,
                        Stamina =       16
                    },
                        new Character.Stat()
                    {
                        Agility =      11,
                        Intelligence = 9, 
                        Strength =     16,
                        Stamina =      18
                    },
                        new Character.Stat()
                    {
                        Agility =       12,
                        Intelligence = 10, 
                        Strength =      17,
                        Stamina =       20
                    }
                }
                    
               
               
            });
            
            Characters.Add(new Character 
            { 
                Name = "Healer", 
                Level = 4, 
                   
                  Stats = new List<Character.Stat>()
                {
                    new Character.Stat()
                    {
                        Agility =       10,
                        Intelligence =  14,
                        Strength =       8,
                        Stamina =       10
                    },
                        new Character.Stat()
                    {
                        Agility =      11,
                        Intelligence = 16,
                        Strength =     9, 
                        Stamina =      11
                    },
                    
                        new Character.Stat()
                    {
                        Agility =      12,
                        Intelligence = 17,
                        Strength =    10, 
                        Stamina =      13
                    },
                        new Character.Stat()
                    {
                        Agility =       14,
                        Intelligence =  20,
                        Strength =     10, 
                        Stamina =       14
                    }
                }
            });
            Characters.Add(new Character 
            { 
                Name = "Ranger", 
                Level = 6,  
                
                Stats = new List<Character.Stat>()
                {
                    new Character.Stat()
                    {
                        Agility =        12,
                        Intelligence =   8, 
                        Strength =       10,
                        Stamina =        8
                    },
                        new Character.Stat()
                    {
                        Agility =      14,
                        Intelligence = 9,
                        Strength =     11,
                        Stamina =     10
                    },
                    
                        new Character.Stat()
                    {
                        Agility =       17,
                        Intelligence = 10, 
                        Strength =     12,
                        Stamina =      11
                    },
                        new Character.Stat()
                    {
                        Agility =      18,
                        Intelligence =11,
                        Strength =    13,
                        Stamina =     12
                    },
                    
                        new Character.Stat()
                    {
                        Agility =       20,
                        Intelligence = 12,
                        Strength =     15,
                        Stamina =      13
                    },
                        new Character.Stat()
                    {
                        Agility =      22,
                        Intelligence = 13,
                        Strength =     16,
                        Stamina =      13
                    }
                }
            });
        }
        
    }
