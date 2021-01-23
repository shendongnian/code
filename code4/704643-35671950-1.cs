    public void Transposition(){
		MatRes = new int[Mat1.GetLength(1), Mat1.GetLength(0)];
		for (int i = 0; i < Mat1.GetLength(1); i++){
		    for (int j = 0; j < Mat1.GetLength(0); j++){
		         MatRes[i, j] = Mat1[j, i];
		    }
		}
    }
