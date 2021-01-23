    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Diagnostics;
    using System.Numerics;
    
    namespace Test
    {
        class PhaseList
        {
            private Dictionary<int, Complex> mPhases = new Dictionary<int, Complex>();
    
            public Complex this[int pIndex]
            {
                get
                {
                    Complex lRet;
                    mPhases.TryGetValue(pIndex, out lRet);
                    return lRet;
                }
                set
                {
                    mPhases.Remove(pIndex);
                    mPhases.Add(pIndex, value);
                }
            }
        }
    
        class PhasedType
        {
            private PhaseList mPhases = new PhaseList();
            public PhaseList Phases { get { return mPhases; } }
            public static implicit operator Complex(PhasedType pSelf)
            {
                return pSelf.Phases[1];
            }
    
            public static implicit operator PhasedType(Complex pValue)
            {
                PhasedType lRet = new PhasedType();
                lRet.Phases[1] = pValue;
                return lRet;
            }
        }
    
        class Bus
        {
            public PhasedType Voltage { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Bus lBus = new Bus();
    
                lBus.Voltage = new Complex(1.0, 1.0);
                Complex c = lBus.Voltage;
                lBus.Voltage.Phases[1] = c;
                c = lBus.Voltage.Phases[1];
            }
        }
    }
