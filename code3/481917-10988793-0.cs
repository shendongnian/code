    //So you have a character...
    public class Character
    {
        //You know you ALWAYS need Raw Attribs in a game
        private Dictionary<string, Attrib> _rawAttributes;
        //You know you will always need a record of modified attribs
        private Dictionary<string, Attrib> _modifiedAttributes;
        //And while your at it, take a light optimization to not have to recalculate everytime
        private bool _areModifiedAttribsCurrent { get; set; }
        //A character has gear! This is what makes the world go around
        public List<Equipment> Equipment { get; private set; }
        //You don't want to give public access to setting gear, this should be controlled.
        //You'll want to do more as far as remove / change... but this'll get you started
        public void AddEquipment(Equipment e)
        {
            Equipment.Add(e);
            _areModifiedAttribsCurrent = false;
        }
        //And a way to add attribs and set base values..
        //once again, you will want more but this will get you started
        public void AddAttribute(Attrib x)
        {
            _rawAttributes.Add(x.Name, x);
        }
        //Finally you want a way to fetch the modified attribs
        //Keep in mind you need to do the copy dance in the  apply to not upset your 
        //base stats.
        public Dictionary<string, Attrib> FetchModifiedAttributes()
        {
            if (!_areModifiedAttribsCurrent)
            {
                var traceAttribs = _rawAttributes;
                foreach (var e in Equipment.OrderBy(x => x.ApplyOrder))
                {
                    traceAttribs = e.ApplyModifiers(traceAttribs);
                }
                _modifiedAttributes = traceAttribs;
            }
            return _modifiedAttributes;
        }
    }
    //Attrib, pretty simple.. Could go away but we all know attribs have effects so don't even start down that path
    //You WILL need this class later on... but right now it looks pretty meaningless.
    public class Attrib
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
    //GEAR... yes, this is what all RPG lovers love... 
    //Grind for that awesome gear!
    public class Equipment
    {
        //Ok so I put in some stuff unrelated to your problem but you need a name right?!
        public string Name { get; set; }
        //What order does gear effect stats... this is important if you do more than flat modifiers.
        public int ApplyOrder { get; set; }
        //What modifiers does this gear have?!
        public List<Modifier> ItemModifiers { get; set; }
        //Aha.... let the gear apply its modifiers to an attrib dictionary... I knew I loved OO for some reason
        public Dictionary<string, Attrib> ApplyModifiers(Dictionary<string, Attrib> inParams)
        {
            //Copy / Clone... Whatever you want to call it this is important as to not 
            //unintentionally screw up yoru base collection.
            var response = new Dictionary<string, Attrib>();
            foreach (var m in ItemModifiers)
            {
                //If we have this attrib, keep going
                if (inParams.ContainsKey(m.TargetName))
                {
                    //If this is the first time the response ran into it, add it
                    if (!response.ContainsKey(m.TargetName))
                    {
                        response.Add(m.TargetName, inParams[m.TargetName]);
                    }
                    //And wait what's this... let the Modifier apply it!?  
                    //yes... pass it down again... you'll see why in a second.
                    m.Apply(response[m.TargetName]);
                }
            }
            return response;
        }
    }
    //A modifier... what the!?
    //Yep... abstraction is key to maintainable and expandable code
    public class Modifier
    {
        public string TargetName { get; set; }
        public decimal ModifierValue { get; set; }
        //The other stuff is kind of pointless... but this is where the magic happens... All in a modifier type.
        public ModifierType ModifierType { get; set; }
        //Let the modifier apply it's own values... off the type... yea
        //I did that on purpose ;-)
        public void Apply(Attrib a)
        {
            a.Value = ModifierType.ApplyModifier(this, a.Value);
        }
    }
    //Decoration... Wonderful
    //This base class gives you a interface to work with... Hell, it could be an interface but I decided
    //to type abstract today.
    public abstract class ModifierType
    {
        public abstract string ModifierName { get; }
        public abstract decimal ApplyModifier(Modifier m, decimal InitialValue);
    }
    //A concrete type of ModifierType... This is what determines how the modifier value is applied.
    //This gives you more flexibility than hard coding modifier types.  If you really wanted to you could
    //serialize these and store lambda expressions in the DB so you not only have type driven logic, you could have
    //data driven behavior.
    public class FlatModifier : ModifierType
    {
        //The names can be really handy if you want to expose calculations to players.
        public override string ModifierName { get { return "Flat Effect"; } }
        //And finally... let the calculation happen!  Time to bubble back up!
        public override decimal ApplyModifier(Modifier m, decimal InitialValue)
        {
            return InitialValue + m.ModifierValue;
        }
    }
