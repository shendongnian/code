    public string AbilityName { get; private set; }
        public int minDamage { get; private set; }
        public int maxDamage { get; private set; }
        public int ActivationTime { get; private set; }
        public int CooldownTime { get; private set; }
        public int Timer;
        public Ability(string AbilityName)
        {
            if (AbilityName == "attack")
            {
                this.AbilityName = AbilityName;
                minDamage = 10;
                maxDamage = 20;
                ActivationTime = 20;
                CooldownTime = 30;
                Timer = ActivationTime;
                iconPath = "ability/icon/attack";
            }
        }
