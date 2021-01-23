    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic; // THIS one is very important since it contains the List
    
    public class TestScript : MonoBehaviour {
    	List<int> ListOfIntegers = new List<int>();
    	List<int> ListOfIntegers1 = new List<int>();
    	List<List<int>> ListOfLists = new List<List<int>>();
    	
    	
    	void Start(){
    		ListOfIntegers.Add(1);
    		ListOfIntegers1.Add(10);
    		ListOfLists.Add(ListOfIntegers1);
    		ListOfLists.Add(ListOfIntegers);
    		Debug.Log((ListOfLists[0])[0]); // you get debug 10
    	}
    }
