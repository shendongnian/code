    using UnityEngine;
    using System.Collections;
    using AssemblyCSharp.portal.wwwww.com;
    
    public class Game5_Player : MonoBehaviour
    {
    	public string Logo;
    	void Start ()
    	{
    		crm1 s = new crm1();
     		Logo= s.getCompanyLogo ();
        }
    }
