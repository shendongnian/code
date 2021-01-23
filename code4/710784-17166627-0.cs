    public static bool MoveSection<T>(this LinkedList<T> list, int startIndex, int endIndex, int moveIndex){
        //bounds checking
        if (startIndex < moveIndex && moveIndex < endIndex){
            return false;
        }
        if (list.Count <= startIndex || list.Count <= endIndex || list.Count+1 <= moveIndex){
                return false;
        }
        if (startIndex >= endIndex){
                return false;
        }
        LinkedListNode<T> startNode = list.ElementAt(startIndex);
        LinkedListNode<T> endNode = list.ElementAt(endIndex);
	
        LinkedListNode<T> restMoveNode = null;
        LinkedListNode<T> insertAfterNode;
        if (moveIndex < list.Count) {
                //when not inserting at the end of the list
                restMoveNode = list.ElementAt(moveIndex);
                insertAfterNode	= restMoveNode.Previous;
        } else {
                //when inserting at the end of the list
                insertAfterNode	= list.ElementAt(moveIndex - 1);
        }
        if (insertAfterNode == null){
                //when inserting at the beginning of the list 
                list.AddFirst(startNode);
        } else {	
                insertAfterNode.Next = startNode;
        }
        //restore previous list elements	
        endNode.next = restMoveNode;
	
        return true;
    }
