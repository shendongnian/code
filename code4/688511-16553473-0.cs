    Mesh mesh = new Mesh();
        var renderer = mesh.AddRenderer();
             mesh.vertices = new Vector3[] {
        
                    //vertices in order for convienience  
                    Manager.GUI.ScreenToWorldPoint(new Vector3(0f,0f,0f)),                            //0
                    Manager.GUI.ScreenToWorldPoint(new Vector3(padding,0f,0f)),                      //1
                    Manager.GUI.ScreenToWorldPoint(new Vector3(padding,padding,0)),                   //2
                    Manager.GUI.ScreenToWorldPoint(new Vector3(width - padding, 0f,0f)),              //3
                    Manager.GUI.ScreenToWorldPoint(new Vector3(width - padding, padding,0f)),         //4
                    Manager.GUI.ScreenToWorldPoint(new Vector3(width,0f,0f)),                         //5
                    Manager.GUI.ScreenToWorldPoint(new Vector3(width,padding,0f)),                    //6
                    Manager.GUI.ScreenToWorldPoint(new Vector3(width , height - padding,0f)),         //7
                    Manager.GUI.ScreenToWorldPoint(new Vector3(width - padding, height - padding,0f)),//8
                    Manager.GUI.ScreenToWorldPoint(new Vector3(width,height,0f)),                     //9
                    Manager.GUI.ScreenToWorldPoint(new Vector3(width - padding,height,0f)),           //10
                    Manager.GUI.ScreenToWorldPoint(new Vector3(padding, height, 0f)),                 //11
                    Manager.GUI.ScreenToWorldPoint(new Vector3(padding, height - padding, 0f)),       //12
                    Manager.GUI.ScreenToWorldPoint(new Vector3(0f,height,0f)),                        //13
                    Manager.GUI.ScreenToWorldPoint(new Vector3(0f,height - padding,0f)),              //14
                    Manager.GUI.ScreenToWorldPoint(new Vector3(0f,padding,0f)),                       //15
                };
        
        
        
                //create triangles
                mesh.triangles = new int[] {
                    15,2,0,
                    1,0,2,
                    1,2,4,
                    1,4,3,
                    3,4,6,
                    3,6,5,
                    4,8,7,
                    4,7,6,
                    8,10,9,
                    8,9,7,
                    12,10,8,
                    12,11,10,
                    14,11,12,
                    14,13,11,
                    15,14,12,
                    15,12,2,
                    2,12,8,
                    2,8,4
               
        };
        
                //create UV's uvs are in order of creation for convienience
                   mesh.uv = new Vector2[] {
                       new Vector2(0f,0f),   //0
                       new Vector2(padding / width, 0f), //1
                       new Vector2(padding/width, padding/height), //2
                       new Vector2((width-padding)/width, 0f), //3
                       new Vector2((width-padding)/width, padding/height), //4
                       new Vector2(1f,0f), //5
                       new Vector2(1f,padding / height), //6
                        new Vector2(1f, (height - padding) / height), //7
                       new Vector2((width - padding)/width,(height-padding)/height),//8
                       new Vector2(1f,1f), //9
                        new Vector2((width -padding)/width,1f), //10
                        new Vector2(padding/width,1f), //11
                       new Vector2(padding/width,(height-padding)/height), //12
                       new Vector2(0f,1f), //13
                       new Vector2(0f,(height - padding) / height), //14
                       new Vector2(0f,padding / height) //15
        
                       
           
                 
        
                };
              
        
        
                mesh.RecalculateNormals();
                mesh.RecalculateBounds();
        
                return plane;
