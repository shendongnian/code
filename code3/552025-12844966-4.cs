    public Ability ability { get; private set; }
        public bool onCooldown;
        public Creature attacker { get; private set; }
        List<Creature> targets = new List<Creature>();
        
        /// <summary>
        /// Initiates a attack task
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        public Task(Creature attacker, List<Creature> targets, Ability ability)
        {
            this.ability = ability;
            this.attacker = attacker;
            this.targets = targets;
            onCooldown = false;
        }
        public void Perform()
        {
            //performce abilty
            Console.WriteLine(attacker.Name + " performce ability");
        }
