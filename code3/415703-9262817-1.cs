    [TestCase(-1,2)]
    [TestCase(1, -2)]
    [TestCase(-1, -2)]
    [TestCase(11, 2)]
    [TestCase(1, 20)]
    [TestCase(11, 20)] 
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void testContract_AssaultToHit(int _attacker_weaponskill, 
        int _defender_weaponskill)
    {
        Warhammer40kRules.assaultToHit(_attacker_weaponskill, 
            _defender_weaponskill);
    }
