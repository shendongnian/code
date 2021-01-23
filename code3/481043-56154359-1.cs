using System.Collections;
using System.Collections.Generic;
public class Map<E, F> : IEnumerable<KeyValuePair<E, F>>
{
	private readonly Dictionary<E, F> _left = new Dictionary<E, F>();
	public IReadOnlyDictionary<E, F> left => this._left;
	private readonly Dictionary<F, E> _right = new Dictionary<F, E>();
	public IReadOnlyDictionary<F, E> right => this._right;
	public void RemoveLeft(E e)
	{
		if (!this.left.ContainsKey(e)) return;
		this._right.Remove(this.left[e]);
		this._left.Remove(e);
	}
	public void RemoveRight(F f)
	{
		if (!this.right.ContainsKey(f)) return;
		this._left.Remove(this.right[f]);
		this._right.Remove(f);
	}
	public int Count()
	{
		return this.left.Count;
	}
	public void Set(E left, F right)
	{
		if (this.left.ContainsKey(left))
		{
			this.RemoveLeft(left);
		}
		if (this.right.ContainsKey(right))
		{
			this.RemoveRight(right);
		}
		this._left.Add(left, right);
		this._right.Add(right, left);
	}
	public IEnumerator<KeyValuePair<E, F>> GetEnumerator()
	{
		return this.left.GetEnumerator();
	}
	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.left.GetEnumerator();
	}
}
