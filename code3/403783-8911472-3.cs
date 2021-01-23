    foreach ( currentRule in Rules )
       {
              RuleResult r = currentRule.Evaluate();
               if ( r ==  Death )
               {
                     ProcessDeath();
                     break;
               }
              else if ( r == Lives )
              {
                    ProcessLiving();
                    break;
              }
       } 
