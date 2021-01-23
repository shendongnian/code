        public new void ReturnContents(Jewels safeContents, Owner owner)
        {
            stolenJewels = safeContents;
            Console.WriteLine("JewelThief:I'm stealing the contents! " + stolenJewels.Sparkle());
        }
