    using UnityEngine;
    using UnityEditor;
    using System.Collections;
    [CustomPropertyDrawer (typeof (ScaledCurve))]
    public class PropertyDrawerTest : PropertyDrawer {
    public override void OnGUI (Rect pos, SerializedProperty prop, GUIContent label) {
        SerializedProperty myValue = prop.FindPropertyRelative ("myValue");
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 1;
		EditorGUI.PropertyField(
            new Rect(pos.x,pos.y,pos.width,pos.height),
            myValue,
			label
		);
        EditorGUI.indentLevel = indent;
    }
    }
