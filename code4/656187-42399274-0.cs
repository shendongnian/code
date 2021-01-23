    #if UNITY_EDITOR
    using UnityEditor;
    using UnityEngine;
    
    public class LevelEditorHelper : MonoBehaviour
    {
    	LevelEditorHelper()
    	{
    		EditorApplication.hierarchyWindowChanged -= MyHierarchyChangedCallback;
    		EditorApplication.hierarchyWindowChanged += MyHierarchyChangedCallback;
    	}
    
    	private static void MyHierarchyChangedCallback()
    	{
    		Debug.Log("Hierarchy has changed");
    	}
    }
    #endif
