    void OnGUI()
    {
       if(died)
       {
            GUI.Label(new Rect(daX, daY, 200, 40), "You died!!");
            GUI.Label(new Rect(daX, daY-40, 200, 40), whyDie);
            if (GUI.Button(new Rect(daX-75, daY+50, 150, 30), "Respawn!!!"))
            {
                transform.position = new Vector3(-5,20,5);
                died = false; //Stop drawing died interface
            }
            
            if (GUI.Button(new Rect(daX-75, daY+100, 150, 30), "Screw This!!!"))
            {
                Debug.Log("Back to menu");
                Application.LoadLevel(0); //Load your first scene, where the menu is.
            }
        }
     }
