    public class ActionCombiner$0
    {
        $1 _act1,_act2;
        void Invoke($2)
        {
            _act1($3);
            _act2($3);
        }
        ActionCombiner($1 act1, $1 act2)
        {
            _act1 = act1;
            _act2 = act2;
        }
        public $1 Create($1 act1, $1 act2)
        {
            var temp = new ActionCombiner$0(act1, act2);
            return temp.Invoke;
        }
    }
