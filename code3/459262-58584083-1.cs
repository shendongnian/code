        Hook.GlobalEvents().OnCombination(new Dictionary<Combination, Action>
        {
            { Combination.TriggeredBy(Keys.A).Control(), () => { Console.WriteLine("You Pressed CTRL+A"); } },
            { Combination.FromString("Shift+Alt+Enter"), () => { Console.WriteLine("You Pressed FULL SCREEN"); } }
        });
