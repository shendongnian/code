			int startIndex=2;
			int endIndex=5;
			int[] elements=new int[7];
			elements[0]=2; 
			elements[1]=9;
			elements[2]=8;
			elements[3]=3;
			elements[4]=4;
			elements[5]=15;
			elements[6]=11;
			for (int a=startIndex-1;a<endIndex;a++){
				for(int b=startIndex-1;b<endIndex;b++){
					if (elements[a]<elements[b]){
						int temp =elements[a];
						elements[a]=elements[b];
						elements[b]=temp;
					}
				}
			}
			for (int c=0;c<elements.Length;c++){
				Console.Write(elements[c]+",");
			}
